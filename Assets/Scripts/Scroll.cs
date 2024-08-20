using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Scroll : MonoBehaviour
{
    // Start is called before the first frame update
    public ScrollRect scrollRect;

    // Update is called once per frame

        void Update()
        {
            if (scrollRect.normalizedPosition.x <= -0.2f) // Sol kenara yakýnsa
            {
                scrollRect.normalizedPosition = new Vector2(0.5f,scrollRect.normalizedPosition.y);
        }
        }

}
