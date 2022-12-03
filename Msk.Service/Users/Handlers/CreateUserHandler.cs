using MediatR;
using Msk.Data.Contracts.Users;
using Msk.Domain.Shared;
using Msk.Domain.Token;
using Msk.Domain.Users;
using Msk.Service.Token;
using Msk.Service.Users.Commands;


namespace Msk.Service.Users.Handlers
{
    public class CreateUserHandler : IRequestHandler<UserCreateCommand, Response>
    {
        IUsersRepository _usersRepository;
        ITokenService _tokenService;

        public CreateUserHandler(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public async Task<Response> Handle(UserCreateCommand
             request, CancellationToken cancellationToken)
        {

            try
            {
                //validar o codigo
                //validar o tipo e o value
                //pegar o Id e  salvar Na tabela user
                Password password = new();
                User user = new User(request.Name, password.EncodePassword(request.Password));
                
                _usersRepository.AddUser(user);

                if (request.Adress != null)
                {
                    UserCreateAdressCommand adress = request.Adress;
                    Adress adresssave = new Adress(
                        adress.Postcode,
                        adress.City,
                        adress.District,
                        adress.PublicPlace,
                        adress.Number,
                        adress.Complement,
                        adress.State,
                        adress.Country,
                        adress.ReferencPoint,
                        user.Id);
                    _usersRepository.AddAdress(adresssave);

                }
                if (request.Contact != null)
                {

                    UserCreateContactCommand contacts = request.Contact;

                    //gerar o codigo

                    
                       var result= password.GenerationCode();
                    Contact contact = new(user.Id, contacts.Cell, contacts.Email);                    
                                       
                    contact.SetCode(result);



                    _usersRepository.AddContact(contact);

                }

                //Gerando o token e refreshtokem de segurança
                TokenService tokenService = new();
                var token = tokenService.GenerateToken(user.Name);
                if (token == null)
                {
                    new Exception("Error, Token não gerado!");

                }

                UserRefreshTokens userrefreshtoken = new();
                userrefreshtoken.SetRefreshToken(user.Id, request.Name, token.Refresh_Token);
               
                _usersRepository.AddUserRefreshTokens(userrefreshtoken);
              




                return new Response { user = user.Name, cod = 201, Access_Token = token.Access_Token, Refresh_Token = token.Refresh_Token };

                // new Response { message = "Success", code = 201 };


            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}
