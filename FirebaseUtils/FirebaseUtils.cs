namespace Firebase;

using FirebaseAdmin;
using FirebaseAdmin.Auth;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;


public class FirebaseUtils
{
    private FirebaseApp _firebaseInstance;

    public FirebaseUtils()
    {
        _firebaseInstance = FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile("./travel-smart-service-account-key.json")
        });
    }

    public FirebaseApp firebaseInstance => _firebaseInstance;

    public Task<string> SendMessageAsync(string messageText, string topic)
    {

        var messageObject = new Message()
        {
            Data = new Dictionary<string, string> () {
                { "alert", "Storm is coming" }
            },
            Notification = new Notification()
            {
                Body = messageText,
            },
            Topic = topic
        };

        return FirebaseMessaging.GetMessaging(firebaseInstance).SendAsync(messageObject);
    }
}
