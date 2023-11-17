public class EternalGoal : Goal {

    public EternalGoal() : base() {
        
    }
    public EternalGoal(string name, string description, double points, int timesFinished):
    base(name, description, points, timesFinished) {
        
    }
    public override bool IsComplete(){
        return false;
    }
    public override double RecordEvent(){
        base.RecordEvent();
        return AwardPoints(this._points);
    }
    public override string SerializeSelf(){
        this._formattedString = "eternal";
        return base.SerializeSelf();
    }
    public override void ListGoal() {
        base.ListGoal();
        Console.Write($" --- Eternal Goal\n");
    }
    
}




