using Education.Core.Services;
using Firebase.Auth;
using Firebase.Storage;
using Microsoft.AspNetCore.Http;


namespace Education.Service.Services
{
    public class FirebaseStorageServiceImp : IFirebaseStorageService
    {
        #region firebase api const values
        private string apiKey = "AIzaSyDXYZZPVHeBX7vDF5q-DMl8sdgWsj6FnxA";
        private string bucket = "educationapp-b6a38.appspot.com";
        private string AuthEmai = "abdullah.ozkilic@bursaligrubu.com";
        private string AuthPassword = "!Bursali!";
        #endregion

        public async Task<string> UploadFile(IFormFile file)
        {
            string result = "";
            var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
            try
            {
                var login = await auth.SignInWithEmailAndPasswordAsync(AuthEmai, AuthPassword);

                var cancelleation = new CancellationTokenSource();
                var upload = new FirebaseStorage(bucket, new FirebaseStorageOptions()
                {
                    AuthTokenAsyncFactory = () => Task.FromResult(login.FirebaseToken),
                    ThrowOnCancel = true
                }).Child(file.FileName).PutAsync(file.OpenReadStream(), cancelleation.Token);

                result = await upload;
            }
            catch (Exception ex)
            {

                throw;
            }

            return result;
        }
    }
}
