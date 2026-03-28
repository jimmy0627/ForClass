using UnityEngine;
// This script demonstrates the use of abstract classes and interfaces in Unity.
public abstract class Abstract : MonoBehaviour
{
    int area;
    public abstract int GetArea(); // Abstract method that must be implemented by derived classes
}
public interface IDamageable
{
    void TakeDamage(int amount); 
}
public class WoodenBox : MonoBehaviour, IDamageable
{
    public int hp = 10;
    public void TakeDamage(int amount)
    {
        hp -= amount;
        if (hp <= 0) Debug.Log("木箱破裂！");
    }
}