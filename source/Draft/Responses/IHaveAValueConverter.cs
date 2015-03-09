using System;
using System.Linq;

namespace Draft.Responses
{
    internal interface IHaveAValueConverter
    {

        Func<IKeyDataValueConverter> ValueConverter { get; set; }

    }
}
