using System;
using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Repositories;
using DapperStore.Domain.StoreContext.Services;
using DapperStore.Domain.StoreContext.ValueObjects;
using DapperStore.Shared.Commands;
using FluentValidator;

namespace DapperStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : 
        Notifiable, 
        ICommandHandler<CreateCustomerCommand>,
        ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o CPF já existe na base
            if(_repository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF já está em uso");

            //Verificar se o E-mail já existe na base
            if(_repository.CheckEmail(command.Email))
                AddNotification("Email", "Este email já está em uso");
            
            //Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar a entidade
            var customer = new Customer(name, document, email, command.Phone);

            //Validar entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if(!Valid)
                return null;

            //Persistir o cliente
            _repository.Save(customer);

            //Enviar um E-mail de boas vindas
            _emailService.Send(customer.Email.Address, "hello@dapper.com", "Cadastro efetuado", "Bem-vindo");

            //Retornar o resultado para tela

            return new CreateCustomerCommandResult(customer.Id, name.FirstName, name.LastName, document.Number, email.Address, customer.Phone);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}