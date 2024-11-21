using DG.Tweening;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    public void FindPath()
    {
        List<Transform> nextCubes = new List<Transform>();
        List<Transform> pastCubes = new List<Transform>();

        foreach (WalkPath path in GameManager.instance.Player.controller.currentCube.GetComponent<Walkable>().possiblePaths)
        {
            if (path.active)
            {
                nextCubes.Add(path.target);
                path.target.GetComponent<Walkable>().previousBlock = GameManager.instance.Player.controller.currentCube;
            }
        }

        pastCubes.Add(GameManager.instance.Player.controller.currentCube);

        ExploreCube(nextCubes, pastCubes);
        BuildPath();
    }

    public void ExploreCube(List<Transform> nextCubes, List<Transform> visitedCubes)
    {
        Transform current = nextCubes.First();
        nextCubes.Remove(current);

        if (current == GameManager.instance.Player.controller.clickedCube)
        {
            return;
        }

        foreach (WalkPath path in current.GetComponent<Walkable>().possiblePaths)
        {
            if (!visitedCubes.Contains(path.target) && path.active)
            {
                nextCubes.Add(path.target);
                path.target.GetComponent<Walkable>().previousBlock = current;
            }
        }

        visitedCubes.Add(current);

        if (nextCubes.Any())
        {
            ExploreCube(nextCubes, visitedCubes);
        }
    }

    public void BuildPath() // 경로 생성
    {
        Transform cube = GameManager.instance.Player.controller.clickedCube;
        while (cube != GameManager.instance.Player.controller.currentCube)
        {
            GameManager.instance.Player.controller.finalPath.Add(cube);
            if (cube.GetComponent<Walkable>().previousBlock != null)
                cube = cube.GetComponent<Walkable>().previousBlock;
            else
                return;
        }

        GameManager.instance.Player.controller.finalPath.Insert(0, GameManager.instance.Player.controller.clickedCube);

        FollowPath();
    }

    public void FollowPath() // 생성한 경로를 통해 이동
    {
        Sequence s = DOTween.Sequence();

        GameManager.instance.Player.controller.isMoving = true;

        for (int i = GameManager.instance.Player.controller.finalPath.Count - 1; i > 0; i--)
        {
            float time = GameManager.instance.Player.controller.finalPath[i].GetComponent<Walkable>().isStair ? 1.5f : 1;

            s.Append(transform.DOMove(GameManager.instance.Player.controller.finalPath[i].GetComponent<Walkable>().GetWalkPoint(), .2f * time).SetEase(Ease.Linear));

            if (!GameManager.instance.Player.controller.finalPath[i].GetComponent<Walkable>().dontRotate)
                s.Join(transform.DOLookAt(GameManager.instance.Player.controller.finalPath[i].position, .1f, AxisConstraint.Y, Vector3.up));
        }

        s.AppendCallback(() => Clear());
    }

    void Clear()
    {
        foreach (Transform t in GameManager.instance.Player.controller.finalPath)
        {
            t.GetComponent<Walkable>().previousBlock = null;
        }
        GameManager.instance.Player.controller.finalPath.Clear();
        GameManager.instance.Player.controller.isMoving = false;
    }
}
