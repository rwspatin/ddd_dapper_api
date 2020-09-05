using System;
using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using DapperStore.Domain.StoreContext.Entities;
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
        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o CPF já existe na base

            //Verificar se o E-mail já existe na base

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

            //Persistir o cliente

            //Enviar um E-mail de boas vindas

            //Retornar o resultado para tela

            return new CreateCustomerCommandResult(Guid.NewGuid(), name.FirstName, name.LastName, document.Number, email.Address, customer.Phone);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}