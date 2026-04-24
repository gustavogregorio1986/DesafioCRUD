using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesafioCRUD.DTO.Tasks
{
    public record TaskUpdateDto(string Title, DateTime? DueDate, TaskStatus Status);
}
