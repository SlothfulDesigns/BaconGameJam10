using System.Collections.Generic;
using UnityEngine;

public class Quest {
    private bool completed, started, failed, ordered = false;
    public string id, name, description;
    public List<Objective> objectives;

    public Quest(){
        objectives = new List<Objective>();
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
            //quest is ordered and this isn't the first objective
            if (ordered && objective.orderNumber > 0)
            {
                int previous = objective.orderNumber - 1;
                if (!GetObjective(previous).Complete)
                {
                    Fail("Previous objective was incomplete.");
                    return false;
                }
            }
            objective.Complete();
            return true;
        }
        Debug.LogError("Error in quest " + this.id + ": cannot find objective " + name);
        return false;
    }

    public void Complete() 
    {
        this.completed = true;
        Debug.Log("Quest completed: " + id);
    }

    public void Start() 
    {
        this.started = true;
        Debug.Log("Quest started: " + id);
    }

    public void Fail(string reason) 
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

    public Objective()
    {
    }

    public Objective(string id, string description)
    {
    }

    public void Complete()
    {
        this.completed = true;
        Debug.Log("Objective completed: " + id);
    }
}
