using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AutoMapper;
using VeterinaryClinicTest.BusinessLogic.Dto;
using VeterinaryClinicTest.BusinessLogic.Services.Abstractions.Helpers;
using VeterinaryClinicTest.DataAccess.Models;

namespace VeterinaryClinicTest.BusinessLogic.Services.Implementation.Helpers
{
    public class ClientSearch : ISearchClientService
    {
        private readonly IMapper _mapper;
        public ClientSearch(IMapper mapper)
        {
            _mapper = mapper;
        }
        public async Task<IList<ClientListDto>> Search(IEnumerable<Client> clients,string searchString)
        {
            var list = new List<Client>();
            foreach (var client in clients)
            {
                var clientNumber = Regex.Replace(client.PhoneNumber, " *[\\-+|\"-)]+ *", "");
                searchString = Regex.Replace(searchString, " *[\\-+_|\"-)]+ *", "");
                if (await FindSubstring(searchString.ToLower(), client.Name.ToLower()) || await FindSubstring(searchString, clientNumber))
                {
                    list.Add(client);
                }
            }
            return _mapper.Map<IList<ClientListDto>>(list);
        }


        private int[] GetPrefix(string s)
        {
            int[] result = new int[s.Length];
            result[0] = 0;
            int index = 0;

            for (int i = 1; i < s.Length; i++)
            {
                while (index >= 0 && s[index] != s[i]) { index--; }
                index++;
                result[i] = index;
            }

            return result;
        }

        private async Task<bool> FindSubstring(string pattern, string text)
        {
            var pf = await Task<int[]>.Run(() => GetPrefix(pattern));
            int index = 0;

            for (int i = 0; i < text.Length; i++)
            {
                while (index > 0 && pattern[index] != text[i]) { index = pf[index - 1]; }
                if (pattern[index] == text[i]) index++;
                if (index == pattern.Length)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

