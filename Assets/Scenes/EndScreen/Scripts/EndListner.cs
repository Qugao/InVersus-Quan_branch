using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class EndListner : MonoBehaviour
{
    public TextMeshProUGUI s1Text;
    public TextMeshProUGUI s2Text;
    public TextMeshProUGUI s3Text;
    public TextMeshProUGUI s4Text;

    public Image winner;
    public Image second;
    public Image third;
    public Image fourth;

    public TextMeshProUGUI quote;
    public int total = 4;

    private Character p1;
    private Character p2;
    private Character p3;
    private Character p4;

    private float s1 = 0;
    private float s2 = 0;
    private float s3 = 0;
    private float s4 = 0;

    private PriorityQueue<Score> pq = new PriorityQueue<Score>();


    void Start()
    {
        // Get all the scores then add to th priority queue
        s1 = GameObject.Find("passScore").GetComponent<StateManager>().getS1();
        s2 = GameObject.Find("passScore").GetComponent<StateManager>().getS2();
        s3 = GameObject.Find("passScore").GetComponent<StateManager>().getS3();
        s4 = GameObject.Find("passScore").GetComponent<StateManager>().getS4();

        p1 = GameObject.Find("passScore").GetComponent<StateManager>().getP1();
        p2 = GameObject.Find("passScore").GetComponent<StateManager>().getP2();
        p3 = GameObject.Find("passScore").GetComponent<StateManager>().getP3();
        p4 = GameObject.Find("passScore").GetComponent<StateManager>().getP4();

        int index = RandomNumber(0, 4);
        Score player1 = new Score("P1", s1, p1.endArtwork, p1.endArtwork2, p1.quotes[index], new Color32(115,251,253,255));
        pq.Enqueue(player1);

        Score player2 = new Score("P2", s2, p2.endArtwork, p2.endArtwork2, p2.quotes[index], new Color32(206, 47, 131,255));
        pq.Enqueue(player2);

        if (p3 != null)
        {
            Score player3 = new Score("P3", s3, p3.endArtwork, p3.endArtwork2, p3.quotes[index], new Color32(117, 248, 76,255));
            pq.Enqueue(player3);
        }
        else {
            s3Text.text = "";
            GameObject.Find("b3").SetActive(false);
            GameObject.Find("ThirdPic").SetActive(false);
        }

        if (p4 != null) {
            Score player4 = new Score("P4", s4, p4.endArtwork, p4.endArtwork2, p4.quotes[index], new Color32(255, 253, 84,255));
            pq.Enqueue(player4);
        }
        else {
            s4Text.text = "";
            GameObject.Find("b4").SetActive(false);
            GameObject.Find("FourthPic").SetActive(false);
        }

        updateScore();
    }


    public void updateScore() {
        // Update text for score
        Score s;
        if (p4 != null)
        {
            s = pq.Dequeue();
            s4Text.text = "4th: " + s.ToString();
            s4Text.color = s.getColor();
            fourth.sprite = s.getImg2();
        }

        if (p3 != null)
        {
            s = pq.Dequeue();
            s3Text.text = "3rd: " + s.ToString();
            s3Text.color = s.getColor();
            third.sprite = s.getImg2();
        }

        s = pq.Dequeue();
        s2Text.text = "2nd: " + s.ToString();
        s2Text.color = s.getColor();
        second.sprite = s.getImg2();

        s = pq.Dequeue();
        s1Text.text = "Winner " + s.ToString();
        s1Text.color = s.getColor();
        winner.sprite = s.getImg1();
        quote.text = s.getQuote();
    }

    public int RandomNumber(int min, int max)
    {
        System.Random random = new System.Random();
        return random.Next(min, max);
    }
}

// Custom score class
public class Score : IComparable<Score>
{
    public string name;
    public float priority; // smaller values are higher priority
    public Sprite img1;
    public Sprite img2;
    public string quote;
    public Color32 color;

    public Score(string name, float priority, Sprite img1, Sprite img2, string quote, Color32 color)
    {
        this.name = name;
        this.priority = priority;
        this.img1 = img1;
        this.img2 = img2;
        this.quote = quote;
        this.color = color;
    }

    public Sprite getImg1() {
        return this.img1;
    }

    public Sprite getImg2() {
        return this.img2;
    }

    public string getQuote() {
        return this.quote;
    }

    public Color32 getColor() {
        return this.color;
    }

    public override string ToString()
    {
        return name + ", " + priority.ToString("F1");
    }

    public int CompareTo(Score other)
    {
        if (this.priority < other.priority) return -1;
        else if (this.priority > other.priority) return 1;
        else return 0;
    }
} 

// PriorityQueue for sorting score
public class PriorityQueue<T> where T : IComparable<T>
{
    private List<T> data;

    public PriorityQueue()
    {
        this.data = new List<T>();
    }

    public void Enqueue(T item)
    {
        data.Add(item);
        int ci = data.Count - 1; // child index; start at end
        while (ci > 0)
        {
            int pi = (ci - 1) / 2; // parent index
            if (data[ci].CompareTo(data[pi]) >= 0) break; // child item is larger than (or equal) parent so we're done
            T tmp = data[ci]; data[ci] = data[pi]; data[pi] = tmp;
            ci = pi;
        }
    }

    public T Dequeue()
    {
        // assumes pq is not empty; up to calling code
        int li = data.Count - 1; // last index (before removal)
        T frontItem = data[0];   // fetch the front
        data[0] = data[li];
        data.RemoveAt(li);

        --li; // last index (after removal)
        int pi = 0; // parent index. start at front of pq
        while (true)
        {
            int ci = pi * 2 + 1; // left child index of parent
            if (ci > li) break;  // no children so done
            int rc = ci + 1;     // right child
            if (rc <= li && data[rc].CompareTo(data[ci]) < 0) // if there is a rc (ci + 1), and it is smaller than left child, use the rc instead
                ci = rc;
            if (data[pi].CompareTo(data[ci]) <= 0) break; // parent is smaller than (or equal to) smallest child so done
            T tmp = data[pi]; data[pi] = data[ci]; data[ci] = tmp; // swap parent and child
            pi = ci;
        }
        return frontItem;
    }

    public T Peek()
    {
        T frontItem = data[0];
        return frontItem;
    }

    public int Count()
    {
        return data.Count;
    }

    public override string ToString()
    {
        string s = "";
        for (int i = 0; i < data.Count; ++i)
            s += data[i].ToString() + " ";
        s += "count = " + data.Count;
        return s;
    }

    public bool IsConsistent()
    {
        // is the heap property true for all data?
        if (data.Count == 0) return true;
        int li = data.Count - 1; // last index
        for (int pi = 0; pi < data.Count; ++pi) // each parent index
        {
            int lci = 2 * pi + 1; // left child index
            int rci = 2 * pi + 2; // right child index

            if (lci <= li && data[pi].CompareTo(data[lci]) > 0) return false; // if lc exists and it's greater than parent then bad.
            if (rci <= li && data[pi].CompareTo(data[rci]) > 0) return false; // check the right child too.
        }
        return true; // passed all checks
    } // IsConsistent
} // PriorityQueue

