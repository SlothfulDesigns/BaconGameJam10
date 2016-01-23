using System.Collections.Generic;
using UnityEngine;

public class Quest {
    private bool completed, started, failed, ordered = false;
    private int objectivesCompleted = 0;

    public bool completesLevel = false;
    public string id, name, description;
    public List<Objective> objectives;

    public Quest(string id, string name, bool ordered){
        this.id = id;
        this.name = name;
        this.ordered = ordered;
        objectives = new List<Objective>();
    }

    public bool IsCompleted()
    {
        return completed;
    }

    public void AddObjective(Objective objective)
    {
        if (ordered && objectives.Count > 0 && objective.orderNumber == 0)
        {
            objective.orderNumber = objectives.Count + 1;
        }
        objectives.Add(objective);
    }

    public Objective GetObjective(string id) 
    {
        foreach (var o in objectives)
        {
            if (o.id.Equals(id))
                return o;
        }
        return null;
    }

    public Objective GetObjective(int number)
    {
        if (ordered)
        {
            foreach (var o in objectives)
            {
                if (o.orderNumber == number)
                {
                    return o;
                }
            }
        }
        return null;
    }

    public bool CompleteObjective(string name) 
    {
        var objective = GetObjective(name);
        if (objective != null)
        {
            if (objective.IsCompleted())
                return false;

            //quest is ordered and this isn't the first objective
            if (ordered && objective.orderNumber > 0)
            {
                int previous = objective.orderNumber - 1;
                if (!GetObjective(previous).IsCompleted())
                {
                    FailQuest("Previous objective was incomplete.");
                    return false;
                }
            }
            objective.Complete();
            objectivesCompleted++;

            if (objectivesCompleted == objectives.Count)
            {
                CompleteQuest();
            }

            return true;
        }
        Debug.LogError("Error in quest " + this.id + ": cannot find objective " + name);
        return false;
    }

    public void CompleteQuest() 
    {
        this.completed = true;
        Debug.Log("Quest completed: " + id);
    }

    public void StartQuest() 
    {
        this.started = true;
        Debug.Log("Quest started: " + id);
    }

    public void FailQuest(string reason) 
    {
        this.failed = true;
        Debug.Log("Quest failed: " + id + ". " + reason);
    }
}

public class Objective 
{
    private bool completed = false;
    public string id, description;
    public int orderNumber = 0;

    public Objective(string id)
    {
        this.id = id;
    }

    public void Complete()
    {
        this.completed = true;
        Debug.Log("Objective completed: " + id);
    }

    public bool IsCompleted(){
        return this.completed;
    }
}
