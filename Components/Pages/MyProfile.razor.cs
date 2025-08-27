using System.Linq;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing.Tree;

namespace BlazorApp1.Components.Pages
{
    public partial class MyProfile
    {
        Person person = new Person();
        Person updatablePerson = new Person();
        private long lastId = 1;

        List<Person> persons = new List<Person>();

        private void AddInfoToList()
        {
            
            persons.Add(person);
            GenerateNewPerson();
        }

        private void SortByName()
        {
            persons = persons.OrderBy(a => a.Name).ToList();
        }
        private void SortBySum()
        {
            persons.Sort((s1, s2) => s1.Age.CompareTo(s2.Age));
        }
        private void Delete(long Id)
        {
            foreach (Person person in persons)
            {
                if (person.Id == Id)
                {
                    persons.Remove(person);
                    break;
                }
            }
        }
        private void GenerateNewPerson()
        {
            person = new Person();
            lastId++;
            person.Id = lastId;
        }
        private void Edit(long Id)
        {
            foreach (Person per in persons)
            {
                if (per.Id == Id)
                {
                    updatablePerson.Id = per.Id;
                    updatablePerson.Name = per.Name;
                    updatablePerson.Surname = per.Surname;
                    updatablePerson.Age = per.Age;
                    updatablePerson.Address = per.Address;
                    break;
                }
            }
        }

        private void UpdateUser()
        {
            foreach (Person per in persons)
            {
                if (per.Id == updatablePerson.Id)
                {
                    per.Name = updatablePerson.Name;
                    per.Surname = updatablePerson.Surname;
                    per.Age = updatablePerson.Age;
                    per.Address = updatablePerson.Address;
                }
            }
        }

           
    }
}
