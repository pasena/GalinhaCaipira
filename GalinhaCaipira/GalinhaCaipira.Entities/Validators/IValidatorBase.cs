using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GalinhaCaipira.Domain.Validators
{
    public interface IValidatorBase<T> where T : class
    {
        void Validate(T obj);
    }
}
