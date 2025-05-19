using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OrderingSystem.Core.Bases;
using OrderingSystem.Data.Commons;
using MediatR;

namespace OrderingSystem.Core.Features.Categories.Commands.Models
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public LocalizableEntity Name { get; set; } = new LocalizableEntity();
        public string Description { get; set; } = string.Empty;
    }
}
