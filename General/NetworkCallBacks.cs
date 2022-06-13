using Photon.Bolt;
[BoltGlobalBehaviour]
public class NetworkCallbacks : Photon.Bolt.GlobalEventListener
{
    public override void BoltStartBegin()
    {
        BoltNetwork.RegisterTokenClass<Photon.Bolt.PhotonRoomProperties>();
        BoltNetwork.RegisterTokenClass<WeaponDropToken>();
        BoltNetwork.RegisterTokenClass<PlayerToken>();
    }

    public override void SceneLoadLocalDone(string scene, Photon.Bolt.IProtocolToken token)
    {
        if (BoltNetwork.IsServer)
        {
            if (scene == HeadlessServerManager.Map())
            {
                if (!GameController.Current)
                    BoltNetwork.Instantiate(BoltPrefabs.GameController);
            }
        }
    }
}