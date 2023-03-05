using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace DevTool2015
{
    class NAVProcedure:NAVObject
    {
        public bool Local;

        public NAVProcedure(string pText)
        {
            Text = pText;
            Parse();
        }
        
        private void Parse()
        {
            //заголовок
            {
                string pattern = @"(?<local>(LOCAL\s)?)PROCEDURE\W?(?<name>[^\@]+)\@(?<number>\d+)\(";
                Regex newReg = new Regex(pattern);
                Match mat = newReg.Match(Text);
                if (mat.Success)
                {
                    Number = int.Parse(mat.Groups["number"].Value);
                    Name = mat.Groups["name"].Value;
                    if (mat.Groups["local"].Value.Length > 0)
                        Local = true;
                    else Local = false;
                }
            }
            //локальные переменные
            VarObjects = new List<VarObject>();
            FindRecords();
            FindPages();
            FindReports();
            FindCodeunits();
            FindQueries();
            FindXMLPorts();
            //AddNumbers(); //понадобится, когда появятся вызовы объектов без переменных. Тогда нужно проверить правильность доступа к AllObjects
            //и надо будет убрать поиск по DataItem и другим спискам, которых в процедуре нет
        }
        public new string WhereUsed(NAVTypes rectype, int recnumber)
        {
            string result = "";
            List<VarObject> resList;
            resList = VarObjects.FindAll(x => (x.Type == rectype) && (x.Subtype == recnumber));
            foreach (VarObject rec in resList)
            //    foreach (VarObject rec in VarObjects)
            {
              //  if (rec.Subtype == recnumber)
                    result += ("\tProcedure " + Name + ", name = " + rec.Name + "\r\n");
            }
            return (result);
        }
    }
}
