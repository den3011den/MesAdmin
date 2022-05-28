using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MesAdmin_Common
{
    public static class SD
    {
        public const string EquipmentDataPrefix = "|||CN=" ;
        public const string EquipmentDataPostfix = ",CN=Instances,CN=Equipment,CN=SOAProject,CN=Projects,OU=Publications,O=Proficy";

        public static List<Guid> GetEquipmentListFromEquipmentsDataString(string EquipmentsDataString)
        {
            List<Guid> returtList = new List<Guid>();
            if(String.IsNullOrEmpty(EquipmentsDataString))
            {
                return returtList;
            }

            string testString = EquipmentsDataString;

            int EquipmentDataPrefixLength = EquipmentDataPrefix.Length;
            int EquipmentDataPostfixLength = EquipmentDataPostfix.Length;

            int startIndex = 0;
            //int endIndex = 0;

            while (!String.IsNullOrEmpty(testString))
            {
                startIndex = testString.IndexOf(EquipmentDataPrefix);
                if (startIndex < 0)
                    break;

                startIndex = startIndex + EquipmentDataPrefixLength;

                Guid tempGuid = Guid.Empty;
                
                if (Guid.TryParse(testString.Substring(startIndex, 36),out tempGuid))
                {                    
                    returtList.Add(tempGuid);
                }

                testString = testString.Substring(startIndex + 36);
            }

            return returtList;
        }

        public static string GetEquipmentsDataStringFromEquipmentList(List<Guid> equipmentList)
        {
            string returnString = "";
            if (equipmentList.Count > 0)
            {
                foreach (Guid equipment in equipmentList)
                {
                    returnString = returnString + EquipmentDataPrefix + equipment.ToString() + EquipmentDataPostfix;
                }
                return returnString;
            }
            else
                return String.Empty;
        }

    }
}
