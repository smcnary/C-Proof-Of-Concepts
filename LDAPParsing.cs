//Reads and parses text delimited list into List object. 

public List<Employee> ParseLDAP(string fileName)
 {
            try
            {
                FileInfo file = new FileInfo(Server.MapPath("~/MyFiles/" + fileName));
                string[] delimitedByLine = System.IO.File.ReadAllText(file.FullName).Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                var employeeList = delimitedByLine.Select(x =>
                {
                    string[] delimitedByTab = x.Split(new string[] { "\t" }, StringSplitOptions.None);
                    return new Employee()
                    {
                        DomainName = delimitedByTab[0].Replace("\"", ""),
                        Name = delimitedByTab[1],
                        SamAccountName = delimitedByTab[2],
                        GivenName = delimitedByTab[3],
                        Surname = delimitedByTab[4],
                        Email = delimitedByTab[5],
                        PhysicalDeliveryOfficeName = delimitedByTab[6]
                    };
                }).ToList();
                return PartialView("~/Views/Shared/_Employees", employeeList);
            }
            catch (Exception ex)
            {
              throw new InvalidOperationException();
            }
 }
