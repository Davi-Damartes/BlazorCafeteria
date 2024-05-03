using Microsoft.JSInterop;
namespace LojaSonhoDeCafe.Extensions
{
    public static class JsRuntimeExtension
    {
        //Pagamento realizado com sucesso.
        public static ValueTask ToastrSuccess(this IJSRuntime jSRuntime, string message)
        {
            return jSRuntime.InvokeVoidAsync("ShowToastr", "success", message);
        }
        //Falha ao realizar o Pagamento.
        public static ValueTask ToastrFail(this IJSRuntime jSRuntime, string message)
        {
            return jSRuntime.InvokeVoidAsync("ShowToastr", "fail", message);
        }
    }
}
