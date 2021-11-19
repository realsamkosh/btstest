using bts.Models;
using bts.Services.Contracts;
using bts.utitlity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bts.Services.Handlers
{
    public class PersonService : IPersonSerive
    {
        public static List<Person> data = new();
        public PersonService()
        {

        }
        public PersonViewModel GetById(int id)
        {
            try
            {
                var fetchdata = data.FirstOrDefault(x => x.Id == id);
                if (fetchdata != null)
                {
                    return new PersonViewModel
                    {
                        Id = fetchdata.Id,
                        Age = fetchdata.Age,
                        DateOfBirth = fetchdata.DateOfBirth,
                        Name = fetchdata.Name
                    };
                }
                return new PersonViewModel();
            }
            catch (Exception)
            {
                return new PersonViewModel();
            }
        }

        public ResponseModel Insert(PersonDto model)
        {
            try
            {
                //Check the User
                var checkperson = data
                    .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
                if (checkperson != null)
                {
                    return new ResponseModel
                    {
                        message = "Data Exist",
                        status = 400,
                        success = false,
                    };
                }

                if (model.Age <= 0)
                {
                    return new ResponseModel
                    {
                        message = "Age must be Greater then 0",
                        status = 400,
                        success = false,
                    };
                }

                if (string.IsNullOrEmpty(model.Name))
                {
                    return new ResponseModel
                    {
                        message = "Name is required",
                        status = 400,
                        success = false,
                    };
                }
                //Get total count of
                var totalcount = data.Count();
                var id = totalcount == 0 ? 1 : totalcount + 1;
                Person person = new Person
                {
                    Age = model.Age,
                    DateOfBirth = model.DateOfBirth,
                    Id = id,
                    Name = model.Name
                };
                data.Add(person);
                return new ResponseModel
                {
                    data = person,
                    message = "Successful",
                    status = 1,
                    success = true
                };
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<PersonViewModel> List()
        {
            try
            {
                return data.Select(x => new PersonViewModel
                {
                    Name = x.Name,
                    Age = x.Age,
                    DateOfBirth = x.DateOfBirth,
                    Id = x.Id

                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
