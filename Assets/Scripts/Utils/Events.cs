
public class GameEvent
{

}

public static class GameEvents{
    public static CheckHotUpdateEndNotify CheckHotUpdateEndNotify = new CheckHotUpdateEndNotify();
    public static ShowBackButtonPanelNotify ShowBackButtonPanelNotify = new ShowBackButtonPanelNotify();
    public static CloseBackButtonPanelNotify CloseBackButtonPanelNotify = new CloseBackButtonPanelNotify();
    public static ShowLoadingPanelNotify ShowLoadingPanelNotify = new ShowLoadingPanelNotify();
    public static CloseLoadingPanelNotify CloseLoadingPanelNotify = new CloseLoadingPanelNotify();
    public static RestorePanelNotify RestorePanelNotify = new RestorePanelNotify();
    public static ShowBattleLittleMenuPanelNotify ShowBattleLittleMenuPanelNotify = new ShowBattleLittleMenuPanelNotify();
    public static HideBattleLittleMenuPanelNotify HideBattleLittleMenuPanelNotify = new HideBattleLittleMenuPanelNotify();

    // public static ShowTwiceConfirmPanelNotify ShowTwiceConfirmPanelNotify = new ShowTwiceConfirmPanelNotify();

    public static PlayerShootingNotify PlayerShootingNotify = new PlayerShootingNotify();

    public static PlayerMainGunUpdateNotify PlayerMainGunUpdateNotify = new PlayerMainGunUpdateNotify();

    public static PlayerHandGunUpdateNotify PlayerHandGunUpdateNotify = new PlayerHandGunUpdateNotify();
}

public class CheckHotUpdateEndNotify : GameEvent{
        
}
public class ShowBackButtonPanelNotify : GameEvent{

}
public class CloseBackButtonPanelNotify : GameEvent{

}

public class ShowLoadingPanelNotify : GameEvent{

}

public class CloseLoadingPanelNotify : GameEvent{

}

public class RestorePanelNotify : GameEvent{

}

public class ShowBattleLittleMenuPanelNotify : GameEvent{

}

public class HideBattleLittleMenuPanelNotify : GameEvent{

}

// public class ShowTwiceConfirmPanelNotify : GameEvent{

// }

public class PlayerShootingNotify : GameEvent{

}

public class PlayerMainGunUpdateNotify : GameEvent{

}

public class PlayerHandGunUpdateNotify : GameEvent{

}