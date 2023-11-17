public class SimpleGoal : Goal {
    public SimpleGoal() : base() {
        
    }
    public SimpleGoal(string name, string description, double points, int timesFinished):
    base(name, description, points, timesFinished){

    }

    public override bool IsComplete(){
        if(this._timesCompleted >= 1){
            return true;
        }
        else {
            return false;
        }
    }
    public override double RecordEvent(){
        base.RecordEvent();
        return AwardPoints(this._points);
    }
    public override string SerializeSelf(){
        this._formattedString = "simple";
        return base.SerializeSelf();
    }
    public override void ListGoal() {
        base.ListGoal();
        Console.Write($" --- Simple Goal\n");
    }

}
