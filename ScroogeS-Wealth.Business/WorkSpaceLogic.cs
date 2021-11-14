using ScroogeS_Wealth.Models;
using ScroogeS_Wealth.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScroogeS_Wealth.Business
{
    public class WorkSpaceLogic
    {
        public Result<WorkSpace> Get(int userId)
        {
            var workSpace = WorkSpaceStorage.workSpaces.FirstOrDefault(x => x.GeneralUser.Id == userId);
            if(workSpace is null)
            {
                return new Result<WorkSpace>(0, "Рабочее пространство не найдено");
            }
            return new Result<WorkSpace>(1, workSpace, "Ок");
        }
    }
}
