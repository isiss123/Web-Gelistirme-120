using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Main.Business.Abstract
{
    public interface IValidator<T>
    {
        // Directory<string,string> ErrorMessage;  : daha detalli mesaj gosterme
        public string ErrorMessage { get; set; }
        bool Validation(T entity);
    }
}