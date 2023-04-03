using Microsoft.AspNetCore.Razor.TagHelpers;

namespace CRUD_SQLSERVER.TagHelpers
{
    public class MensagemTagHelper : TagHelper
    {
        /*
          @if (TempData["msg"] != null)
            {
                <div class="alert alert-success alert-dismissible fade show">
                    <svg class="bi flex-shrink-0 me-2" width="24" height="24"><use xlink:href="#check-circle-fill" /></svg>
                    @TempData["msg"];
                    <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                </div>

            }
        */

        //<mensagem></mensagem>

        public string Class { get; set; }
        public string Texto { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {

            output.TagName = "div";

            if (string.IsNullOrEmpty(Class))
            {
                output.Attributes.SetAttribute("class", "alert alert-success alert-dismissible fade show");
            }
            else
            {
                output.Attributes.SetAttribute("value", Class);
            }

            output.Content.SetContent(Texto);

        }
    }
}


