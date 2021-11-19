using bts.Models;
using bts.utitlity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bts.Services.Contracts
{
    public interface IPersonSerive
    {
        ResponseModel Insert(PersonDto model);
        List<PersonViewModel> List();
        PersonViewModel GetById(int id);
    }
}
