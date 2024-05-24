using PlayFab;
using PlayFab.ClientModels;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayFabLoginManager : MonoBehaviour
{
    const string LAST_EMAIL_KEY = "LAST_EMAIL";
    const string LAST_PASSWORD_KEY = "LAST_PASSWORD";

    [Header("Références UI")]
    public TMP_Text infoText;

    #region Inscription
    [Header("UI d'Inscription")]
    [SerializeField] TMP_InputField registerUsername;
    [SerializeField] TMP_InputField registerEmail;
    [SerializeField] TMP_InputField registerPassword;
    [SerializeField] TMP_InputField confirmPassword;

    public void OnRegisterPressed()
    {
        string username = registerUsername.text;
        string email = registerEmail.text;
        string password = registerPassword.text;
        string confirmedPassword = confirmPassword.text;

        if (password != confirmedPassword)
        {
            AfficherInfo("Les mots de passe ne correspondent pas.");
            return;
        }

        Register(username, email, password);
    }

    private void Register(string username, string email, string password)
    {
        PlayFabClientAPI.RegisterPlayFabUser(new RegisterPlayFabUserRequest()
        {
            Email = email,
            Username = username,
            Password = password
        },
        successResult =>
        {
            // Set the DisplayName after successful registration
            PlayFabClientAPI.UpdateUserTitleDisplayName(new UpdateUserTitleDisplayNameRequest
            {
                DisplayName = username
            },
            displayNameResult =>
            {
                Login(email, password);
                AfficherInfo("Inscription réussie !");
            },
            error => AfficherInfo("Échec de l'inscription : " + error.ErrorMessage));
        },
        error => AfficherInfo("Échec de l'inscription : " + error.ErrorMessage));
    }
    #endregion

    #region Connexion
    [Header("UI de Connexion")]
    [SerializeField] TMP_InputField loginEmail;
    [SerializeField] TMP_InputField loginPassword;

    public void OnLoginPressed()
    {
        Login(loginEmail.text, loginPassword.text);
    }

    private void Login(string email, string password)
    {
        PlayFabClientAPI.LoginWithEmailAddress(new LoginWithEmailAddressRequest()
        {
            Email = email,
            Password = password,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams()
            {
                GetPlayerProfile = true
            }
        },
        successResult =>
        {
            var profile = successResult.InfoResultPayload.PlayerProfile;


            PlayerPrefs.SetString(LAST_EMAIL_KEY, email);
            PlayerPrefs.SetString(LAST_PASSWORD_KEY, password);


            Debug.Log("Connexion réussie pour l'utilisateur : ");
            AfficherInfo($"Connexion réussie pour l'utilisateur ! ");
            StartCoroutine(DelayedSceneLoad("ProjectPage", 3)); // Ajouter un délai avant de charger la scène
        },
        error => AfficherInfo("Échec de la connexion : " + error.ErrorMessage));
    }
    #endregion

    #region Mot de Passe Oublié
    [Header("UI Mot de Passe Oublié")]
    [SerializeField] TMP_InputField forgetPasswordEmail;

    public void OnForgetPasswordPressed()
    {
        ForgetPassword(forgetPasswordEmail.text);
    }

    private void ForgetPassword(string email)
    {
        PlayFabClientAPI.SendAccountRecoveryEmail(new SendAccountRecoveryEmailRequest()
        {
            Email = email,
            TitleId = PlayFabSettings.TitleId
        },
        result =>
        {
            Debug.Log("Email de récupération du mot de passe envoyé avec succès.");
            AfficherInfo("Email de récupération du mot de passe envoyé avec succès.");
        },
        error => AfficherInfo("Échec de l'envoi de l'email de récupération du mot de passe : " + error.ErrorMessage));
    }
    #endregion

    private void AfficherInfo(string message)
    {
        string username = PlayerPrefs.GetString("Username", "Utilisateur");
        Debug.Log("AfficherInfo - Username: " + username);
        infoText.text = $"{message}\nBienvenue, {username}!";
    }

    // Coroutine pour ajouter un délai avant de charger la scène
    private IEnumerator DelayedSceneLoad(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(sceneName);
    }
}
