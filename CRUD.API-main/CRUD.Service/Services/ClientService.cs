using AutoMapper;
using CRUD.Domain.Dto.Client;
using CRUD.Domain.Dto.ViaCep;
using CRUD.Domain.Interface.Repositories;
using CRUD.Domain.Interface.Services;
using CRUD.Domain.Models;
using CRUD.Service.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;

namespace CRUD.Service.Services
{
    public class ClientService : IClientService
    {
        private readonly IMapper _mapper;
        private readonly IClientRepository _clientRepository;
        public ClientService(IMapper mapper, IClientRepository clientRepository)
        {
            _mapper = mapper;
            _clientRepository = clientRepository;
        }
        public async Task<ClientResponseDto> Create(ClientRegisterDto client)
        {
            
            client.Email = client.Email?.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(client.Email))
                throw new RegraNegocioException("Email é obrigatório.");

            if (!new EmailAddressAttribute().IsValid(client.Email))
                throw new RegraNegocioException("Email inválido.");            

           
            client.Phone = SomenteNumeros(client.Phone);

            if (client.Phone.Length != 10 && client.Phone.Length != 11)
                throw new RegraNegocioException("Telefone deve ter 10 ou 11 dígitos.");

            if (client.Phone.StartsWith("0"))
                throw new RegraNegocioException("DDD não pode começar com 0.");         

            
            client.Cep = SomenteNumeros(client.Cep);

            if (client.Cep.Length != 8)
                throw new RegraNegocioException("CEP deve ter 8 dígitos.");

            var endereco = await BuscarCep(client.Cep);
           

            var entity = _mapper.Map<Client>(client);
            entity.City = endereco.Localidade;
            entity.Uf = endereco.Uf;
            entity.Neighborhood = endereco.Bairro;
            var result = await _clientRepository.Create(entity);

            return _mapper.Map<ClientResponseDto>(result);
        }

        public async Task<ClientResponseDto> Delete(Guid id)
        {
            var rs = await _clientRepository.Delete(id);
            return _mapper.Map<ClientResponseDto>(rs);
        }

        public async Task<List<ClientResponseDto>> GetAll()
        {
            var rs = await _clientRepository.GetAll();
            return _mapper.Map<List<ClientResponseDto>>(rs);
        }

        public async Task<ClientResponseDto> GetById(Guid id)
        {
            var rs = await _clientRepository.GetById(id);
            return _mapper.Map<ClientResponseDto>(rs);
        }

        public async Task<ClientResponseDto> Update(ClientUpdateDto dto)
        {
            var client = await _clientRepository.GetById(dto.Id);

            if (client == null)
                throw new NaoEncontradoException("Cliente não encontrado.");

            
            if (!string.IsNullOrWhiteSpace(dto.Email))
            {
                var email = dto.Email.Trim().ToLower();

                if (!new EmailAddressAttribute().IsValid(email))
                    throw new RegraNegocioException("Email inválido.");                

                client.Email = email;
            }

            
            if (!string.IsNullOrWhiteSpace(dto.Phone))
            {
                var telefone = SomenteNumeros(dto.Phone);

                if (telefone.Length != 10 && telefone.Length != 11)
                    throw new RegraNegocioException("Telefone inválido.");

                if (telefone.StartsWith("0"))
                    throw new RegraNegocioException("DDD inválido.");                

                client.Phone = telefone;
            }

            
            if (!string.IsNullOrWhiteSpace(dto.Cep))
            {
                var cep = SomenteNumeros(dto.Cep);

                if (cep.Length != 8)
                    throw new RegraNegocioException("CEP inválido.");

                if (cep != client.Cep)
                {
                    var endereco = await BuscarCep(cep);

                    client.Cep = cep;
                    client.Street = endereco.Logradouro;
                    client.Neighborhood = endereco.Bairro;
                    client.City = endereco.Localidade;
                    client.Uf = endereco.Uf;
                }
            }

            client.Name = dto.Name ?? client.Name;
            client.Number = dto.Number ?? client.Number;
            client.Complement = dto.Complement ?? client.Complement;

            var result = await _clientRepository.Update(client);

            return _mapper.Map<ClientResponseDto>(result);
        }


        private string SomenteNumeros(string valor)
        {
            return new string(valor.Where(char.IsDigit).ToArray());
        }

        private async Task<ViaCepResponse> BuscarCep(string cep)
        {
            try
            {
                using var http = new HttpClient();
                http.Timeout = TimeSpan.FromSeconds(5);

                var response = await http.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

                if (!response.IsSuccessStatusCode)
                    throw new ServicoIndisponivelException("ViaCEP indisponível.");

                var result = await response.Content.ReadFromJsonAsync<ViaCepResponse>();

                if (result.Erro == true)
                    throw new RegraNegocioException("CEP inválido.");

                return result;
            }
            catch (TaskCanceledException)
            {
                throw new ServicoIndisponivelException("ViaCEP indisponível.");
            }
        }
    }
}
