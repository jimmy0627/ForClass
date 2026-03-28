using UnityEngine;
// This script demonstrates the concept of inheritance and polymorphism in object-oriented programming using Unity.
public class InheritanceDemo
{
    protected string name;
    public void Parent()
    {
        this.name = "Default Name";
    }
    public void Parent(string name)
    {
        this.name = name;
    }
    public virtual void Display(int age = 0)
    {
        Debug.Log("Name: " + name + ", Age: " + age);
    }
}
public class ChildClass : InheritanceDemo
{
    public void Child()
    {
        Parent(); //Calling the parent class method to set the name attribute to default
    }
    public void Child(string name)
    {
        Parent(name); //Calling the parent class method to set the name attribute
    }
    public override void Display(int age)
    {
        Debug.Log("Child Class - Name: " + name + ", Age: " + (age / 2)); // Overriding the Display method to show age as half of the input
    }

}
public class InheritanceDemoScript : MonoBehaviour
{
    void Start()
    {
        ChildClass child = new ChildClass();
        child.Child();
        child.Display(20); // This will call the Display method from the child class with name "Default Name" and age 10 (20/2)
        InheritanceDemo parent=new InheritanceDemo();
        parent.Parent("John Doe");
        parent.Display(30); // This will call the Display method from the parent class with name "John Doe" and age 30
    }
}