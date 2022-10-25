
public class GameEvent
{

}

public static class GameEvents{
    public static CheckHotUpdateEndNotify CheckHotUpdateEndNotify = new CheckHotUpdateEndNotify();
    public static ShowBackButtonPanelNotify ShowBackButtonPanelNotify = new ShowBackButtonPanelNotify();
    public static CloseBackButtonPanelNotify CloseBackButtonPanelNotify = new CloseBackButtonPanelNotify();
    public static ShowLoadingPanelNotify ShowLoadingPanelNotify = new ShowLoadingPanelNotify();
    public static CloseLoadingPanelNotify CloseLoadingPanelNotify = new CloseLoadingPanelNotify();

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