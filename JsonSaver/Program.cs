using JsonSaver;
using Newtonsoft.Json;

Computer myComputer = new(){
    cpu = "M1", 
    ram = "8GB", 
    gpu = "M1", 
    drives = new Drive()
    {
        capacityGB = 256, 
        type = "nVME", 
        name = "SSD"
    }};

StreamWriter sw = new("data.json");
string output = JsonConvert.SerializeObject(myComputer, Formatting.Indented);
sw.Write(output);
sw.Close();