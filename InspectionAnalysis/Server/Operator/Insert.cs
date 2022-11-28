using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InspectionAnalysis.Operator
{
    public class Insert : IDisposable
    {
        private static InspectionDatasContext _db;

        static Insert()
        {
            _db = new InspectionDatasContext();
        }

        public static void InsertInspectResult(InspectResult inspectResult)
        {
            _db.Update(inspectResult);
            //_db.InspectResults.Add(inspectResult);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
