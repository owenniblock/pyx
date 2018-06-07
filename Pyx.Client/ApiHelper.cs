using Newtonsoft.Json;
using Pyx.Shared.Models;
using System;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Pyx.Client
{
    public class ApiHelper
    {
        private readonly string _url;
        private readonly HttpClient client = new HttpClient();

        public ApiHelper(string url)
        {
            _url = url;
        }

        public async Task CreateInstruction(Instruction instruction)
        {
            var url = _url + "/api/instruction";
            var stringContent = new StringContent(JsonConvert.SerializeObject(instruction), Encoding.UTF8, "application/json");
            var streamTask = client.PostAsync(url, stringContent);
            await streamTask;
        }

        public async Task<Instruction> GetInstruction(int id)
        {
            var url = _url + "/api/instruction/" + id;
            var stringTask = client.GetStringAsync(url);
            var stringOutput = await stringTask;
            var instruction = JsonConvert.DeserializeObject<Instruction>(stringOutput);

            return instruction;
        }
    }
}