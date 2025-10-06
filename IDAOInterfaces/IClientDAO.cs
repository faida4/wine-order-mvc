namespace Projet_UA2{
public interface IClientDAO
{
    void SaveClient(Client client);
    Client GetClientById(int clientId);
}
}