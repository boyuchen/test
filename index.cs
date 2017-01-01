using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Qisda.DAL;
using Qisda.Model;

namespace Qisda.Service
{
    public class QisdaService : IQisdaService
    {
        public void Add(HomeLineH h)
        {
            using(QisdaContext context = new QisdaContext())
            {
                context.HomeLineHs.Add(h);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// 获取首件换线历史
        /// </summary>
        /// <param name="id">线别</param>
        /// <returns></returns>
        public HomeLineH GetHomeLineQuery(int id, bool realtime)
        {

            using (var dbContext = new QisdaContext())
            {
                HomeLineH data = new HomeLineH();
                if (!realtime)
                {
                    var hline = dbContext.HomeLineHs.Where(h => h.LineType == id).LastOrDefault();
                    data = hline;
                    data.Assistant = hline.Assistant;
                    data.Technician = hline.Technician;
                }
                return data;
            }           
        }
    }
}
