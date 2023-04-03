// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using ProjetoBanco.Areas.Identity.Data;
using ProjetoBanco.Models;
using ProjetoBanco.Repositories;

namespace projeto_identity.Areas.Identity.Pages.Account
{

    public class RegisterModel : PageModel
    {
        private readonly SignInManager<Cliente> _signInManager;
        private readonly UserManager<Cliente> _userManager;
        private readonly IUserStore<Cliente> _userStore;
        private readonly IUserEmailStore<Cliente> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        private IClienteRepository _clienteRepository;
        public RegisterModel(
            UserManager<Cliente> userManager,
            IUserStore<Cliente> userStore,
            SignInManager<Cliente> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender,
            IClienteRepository clienteRepository)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
            _clienteRepository = clienteRepository;
        }
        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        [BindProperty]
        public InputModel Input { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public string ReturnUrl { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        /// <summary>
        ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
        ///     directly from your code. This API may change or be removed in future releases.
        /// </summary>
        public class InputModel
        {
            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "O campo E-mail é obrigatório.")]
            [EmailAddress]
            [Display(Name = "E-mail")]
            public string Email { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [Required(ErrorMessage = "O campo Senha é obrigatório.")]
            [StringLength(50, ErrorMessage = "Preencha com no mínimo 6 e no máximo 50 caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Senha")]
            public string Password { get; set; }

            /// <summary>
            ///     This API supports the ASP.NET Core Identity default UI infrastructure and is not intended to be used
            ///     directly from your code. This API may change or be removed in future releases.
            /// </summary>
            [DataType(DataType.Password)]
            [Display(Name = "Confirme a senha")]
            [Compare("Password", ErrorMessage = "A senha e a confirmação de senha não coincidem.")]
            public string ConfirmPassword { get; set; }

            [Required(ErrorMessage = "O campo Nome é obrigatório.")]
            [StringLength(80, ErrorMessage = "Preencha com no mínimo 3 e no máximo 80 caracteres.", MinimumLength = 3)]
            public string Nome { get; set; }

            [Display(Name = "CPF")]
            [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Informe os 11 dígitos numéricos do CPF.")]
            [Required(ErrorMessage = "O campo CPF é obrigatório.")]
            public string Cpf { get; set; }

            [Display(Name = "Data de Nascimento")]
            [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
            [DataType(DataType.Date)]
            [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
            public DateTime DataNascimento { get; set; }

            [Required(ErrorMessage = "O campo Telefone é obrigatório.")]
            [RegularExpression(@"^[0-9]{11}$", ErrorMessage = "Informe um número de telefone válido.")]
            public string Telefone { get; set; }

            [Display(Name = "Endereço")]
            [Required(ErrorMessage = "O campo Endereço é obrigatório.")]
            public string Endereco { get; set; }

            [Display(Name = "Tipo de Conta")]
            [Required(ErrorMessage = "O campo tipo de conta é obrigatório.")]
            public TipoConta Tipo { get; set; }
        }


        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/Conta/Index");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = CreateUser();

                bool verificarCpf = _clienteRepository.VerificarCpf(Input.Cpf);
                if (verificarCpf)   //Verifica se cpf já foi cadastrado
                {
                    return RedirectToPage("Register","CPF já cadastrado!");
                }

                user.Nome = Input.Nome;
                user.Cpf = Input.Cpf;
                user.DataNascimento = Input.DataNascimento;
                user.Endereco = Input.Endereco;
                user.Telefone = Input.Telefone;

                if (Input.Tipo == TipoConta.Corrente)
                {
                    user.Conta = new ContaCorrente();
                }
                else
                {
                    user.Conta = new ContaPoupanca();
                }

                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            else
            {
                //redirecionamento para pagina de erro
                return RedirectToAction("Erro", "Home");
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private Cliente CreateUser()
        {
            try
            {
                return Activator.CreateInstance<Cliente>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(Cliente)}'. " +
                    $"Ensure that '{nameof(Cliente)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<Cliente> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<Cliente>)_userStore;
        }
    }
}
