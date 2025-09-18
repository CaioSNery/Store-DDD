using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Domain.ValueObjects;

namespace Store.Domain.Entities
{
    public class Customer : Entity
    {
          // Propriedades
    public Name Name { get; private set; }
    public Email Email { get; private set; }
    public Address Address { get; private set; }
    public Cpf Cpf { get; private set; }
    public List<Order> Orders { get; private set; }

    // Construtor protegido para o EF
    public Customer(string v, string v1) 
    {
        Orders = new List<Order>();
    }

    // Construtor privado recebendo dados crus (strings)
    private Customer(string firstName, string lastName, string email, string address, string cpf)
    {
        Name = Name.Create(firstName, lastName);
        Email = Email.Create(email);
        Address = Address.Create(address);
        Cpf = Cpf.Create(cpf);
        Orders = new List<Order>();
    }

    // Construtor privado recebendo objetos de valor já validados
    private Customer(Name name, Email email, Address address, Cpf cpf)
    {
        Name = name;
        Email = email;
        Address = address;
        Cpf = cpf;
        Orders = new List<Order>();
    }

    // Factory estática recebendo strings
    public static Customer Create(string firstName, string lastName, string email, string address, string cpf)
    {
        return new Customer(firstName, lastName, email, address, cpf);
    }

    // Factory estática recebendo Value Objects
    public static Customer Create(Name name, Email email, Address address, Cpf cpf)
    {
        return new Customer(name, email, address, cpf);
    }

    // Update
    public void Update(string firstName, string lastName, string email, string address, string cpf)
    {
        Name = Name.Create(firstName, lastName);
        Email = Email.Create(email);
        Address = Address.Create(address);
        Cpf = Cpf.Create(cpf);
    }

    }
}