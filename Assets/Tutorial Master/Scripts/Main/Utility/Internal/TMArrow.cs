using UnityEngine;
using HardCodeLab.TutorialMaster;

public class TMArrow {

    public static Vector3 initPos;

    public void AnimateFloatingArrow(GameObject arrowUI, GameObject target, float floatingRange, float floatingSpeed, TutorialMasterScript.arrow_pointing_direction pointDirection)
    {
        float arrow_posDifference = ((Mathf.Sin(Time.time * floatingSpeed) * floatingRange - floatingRange) / 2);

        switch (pointDirection)
        {
            case TutorialMasterScript.arrow_pointing_direction.Top:
                arrowUI.transform.position = new Vector3(
                    initPos.x,
                    initPos.y - arrow_posDifference,
                    initPos.z);
                break;

            case TutorialMasterScript.arrow_pointing_direction.Bottom:
                arrowUI.transform.position = new Vector3(
                    initPos.x,
                    initPos.y + arrow_posDifference,
                    initPos.z);
                break;

            case TutorialMasterScript.arrow_pointing_direction.Left:
                arrowUI.transform.position = new Vector3(
                    initPos.x + arrow_posDifference,
                    initPos.y,
                    initPos.z);
                break;

            case TutorialMasterScript.arrow_pointing_direction.Right:
                arrowUI.transform.position = new Vector3(
                    initPos.x - arrow_posDifference,
                    initPos.y,
                    initPos.z);
                break;

            case TutorialMasterScript.arrow_pointing_direction.TopLeft:
                arrowUI.transform.position = new Vector3(
                    initPos.x + arrow_posDifference,
                    initPos.y - arrow_posDifference,
                    initPos.z);
                break;

            case TutorialMasterScript.arrow_pointing_direction.TopRight:
                arrowUI.transform.position = new Vector3(
                    initPos.x - arrow_posDifference,
                    initPos.y - arrow_posDifference,
                    initPos.z);
                break;

            case TutorialMasterScript.arrow_pointing_direction.BottomLeft:
                arrowUI.transform.position = new Vector3(
                    initPos.x + arrow_posDifference,
                    initPos.y + arrow_posDifference,
                    initPos.z);
                break;

            case TutorialMasterScript.arrow_pointing_direction.BottomRight:
                arrowUI.transform.position = new Vector3(
                    initPos.x - arrow_posDifference,
                    initPos.y + arrow_posDifference,
                    initPos.z);
                break;
        }
    }

    public void PointArrow(GameObject arrowUI, GameObject target, TutorialMasterScript.arrow_pointing_direction pointDirection, float offsetX, float offsetY)
    {
        if (tutorial.isPlaying)
        {
            arrowUI.SetActive(true);

            switch (pointDirection)
            {
                case TutorialMasterScript.arrow_pointing_direction.Top:
                    arrowUI.transform.eulerAngles = new Vector3(0, 0, -90);
                        arrowUI.GetComponent<RectTransform>().position = new Vector3(target.GetComponent<RectTransform>().position.x + offsetX, 
                        target.GetComponent<RectTransform>().position.y + (target.GetComponent<RectTransform>().sizeDelta.y / 2) + offsetY, 
                        0);
                    break;

                case TutorialMasterScript.arrow_pointing_direction.Bottom:
                    arrowUI.transform.eulerAngles = new Vector3(0, 0, 90);
                        arrowUI.GetComponent<RectTransform>().position = new Vector3(target.GetComponent<RectTransform>().position.x + offsetX, 
                        target.GetComponent<RectTransform>().position.y - (target.GetComponent<RectTransform>().sizeDelta.y / 2) + offsetY, 
                        0);
                    break;

                case TutorialMasterScript.arrow_pointing_direction.Left:
                    arrowUI.transform.eulerAngles = new Vector3(0, 0, 0);
                        arrowUI.GetComponent<RectTransform>().position = new Vector3(target.GetComponent<RectTransform>().position.x - (target.GetComponent<RectTransform>().sizeDelta.x / 2) + offsetX,
                        target.GetComponent<RectTransform>().position.y + offsetY,
                        0);
                    break;

                case TutorialMasterScript.arrow_pointing_direction.Right:
                    arrowUI.transform.eulerAngles = new Vector3(0, 180, 0);
                        arrowUI.GetComponent<RectTransform>().position = new Vector3(target.GetComponent<RectTransform>().position.x + (target.GetComponent<RectTransform>().sizeDelta.x / 2) + offsetX, 
                        target.GetComponent<RectTransform>().position.y + offsetY, 
                        0);
                    break;

                case TutorialMasterScript.arrow_pointing_direction.TopLeft:
                    arrowUI.transform.eulerAngles = new Vector3(0, 0, -45);
                        arrowUI.GetComponent<RectTransform>().position = new Vector3(target.GetComponent<RectTransform>().position.x - (target.GetComponent<RectTransform>().sizeDelta.x / 2) + offsetX, 
                        target.GetComponent<RectTransform>().position.y + (target.GetComponent<RectTransform>().sizeDelta.y / 2) + offsetY, 
                        0);
                    break;

                case TutorialMasterScript.arrow_pointing_direction.TopRight:
                    arrowUI.transform.eulerAngles = new Vector3(0, 0, -135);
                        arrowUI.GetComponent<RectTransform>().position = new Vector3(target.GetComponent<RectTransform>().position.x + (target.GetComponent<RectTransform>().sizeDelta.x / 2) + offsetX,
                        target.GetComponent<RectTransform>().position.y + (target.GetComponent<RectTransform>().sizeDelta.y / 2) + offsetY,
                        0);
                    break;

                case TutorialMasterScript.arrow_pointing_direction.BottomLeft:
                    arrowUI.transform.eulerAngles = new Vector3(0, 0, 45);
                        arrowUI.GetComponent<RectTransform>().position = new Vector3(target.GetComponent<RectTransform>().position.x - (target.GetComponent<RectTransform>().sizeDelta.x / 2) + offsetX,
                        target.GetComponent<RectTransform>().position.y - (target.GetComponent<RectTransform>().sizeDelta.y / 2) + offsetY,
                        0);
                    break;

                case TutorialMasterScript.arrow_pointing_direction.BottomRight:
                    arrowUI.transform.eulerAngles = new Vector3(0, 0, 135);
                        arrowUI.GetComponent<RectTransform>().position = new Vector3(target.GetComponent<RectTransform>().position.x + (target.GetComponent<RectTransform>().sizeDelta.x / 2) + offsetX,
                        target.GetComponent<RectTransform>().position.y - (target.GetComponent<RectTransform>().sizeDelta.y / 2) + offsetY,
                        0);
                    break;
            }

            initPos = arrowUI.transform.position;
        }
    }

    public static void DisableArrow(GameObject arrowUI)
    {
        if (arrowUI != null)
        {
            arrowUI.SetActive(false);
        }
    }

}
