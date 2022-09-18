using DataAccess.Repositories.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories.Concretes
{
    public class PizzaRepository : IPizzaRepository
    {
        public void DeleteById(int id)
        {
            Pizza pizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
            StaticDb.Pizzas.Remove(pizzaDb);
        }

        public List<Pizza> GetAll()
        {
            return StaticDb.Pizzas;
        }

        public Pizza GetById(int id)
        {
            return StaticDb.Pizzas.FirstOrDefault(x => x.Id == id);
        }

        public Pizza GetPizzaOnPromotion()
        {
            return StaticDb.Pizzas.FirstOrDefault(x => x.IsOnPromotion);
        }

        public int Insert(Pizza entity)
        {
            entity.Id = ++StaticDb.PizzaId;
            StaticDb.Pizzas.Add(entity);
            return entity.Id;
        }

        public void Update(Pizza entity)
        {
            Pizza PizzaDb = StaticDb.Pizzas.FirstOrDefault(x => x.Id == entity.Id);
            int index = StaticDb.Pizzas.IndexOf(PizzaDb);
            StaticDb.Pizzas[index] = entity;
        }
    }
}
