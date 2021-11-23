using Core;
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
        GenericStorage<WorkSpace> workSpaceStore = new GenericStorage<WorkSpace>();
        public Result<WorkSpace> Get(int userId)
        {
            var workSpace = workSpaceStore.Get().FirstOrDefault(x => x.Id == userId);
            if(workSpace is null)
            {
                return new Result<WorkSpace>(0, "Рабочее пространство не найдено");
            }
            
            return new Result<WorkSpace>(1, workSpace, "Ок");
        }

        public WorkSpace Create()
        {
            WorkSpace workSpace = new WorkSpace();
            workSpace.Id = CreateId(workSpaceStore.Get());
            workSpaceStore.Add(workSpace);
            return workSpace;
        }
        private int CreateId(List<WorkSpace> workSpaces)
        {
            int lastId;
            if (workSpaces.Count == 0)
            {
                lastId = 1;
            }
            else
            {
                lastId = workSpaces.Last().Id + 1;
            }
            return lastId;
        }
    }
}
