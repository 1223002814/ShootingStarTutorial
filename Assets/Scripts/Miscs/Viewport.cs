using UnityEngine;

public class Viewport : Singleton<Viewport>
{
    float maxX;
    float maxY;
    float minX;
    float minY;

    private void Start()
    {
        Camera mainCamera = Camera.main;

        Vector2 bottomLefft = mainCamera.ViewportToWorldPoint(new Vector3(0f, 0f));
        minX = bottomLefft.x;
        minY = bottomLefft.y;

        Vector2 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1f, 1f));
        maxX = topRight.x;
        maxY = topRight.y;
    }

    public Vector3 PlayerMovablePosition(Vector3 playerPosition, float paddingX, float paddingY)
    {
        Vector3 position = Vector3.zero;

        position.x = Mathf.Clamp(playerPosition.x, minX + paddingX, maxX - paddingX);
        position.y = Mathf.Clamp(playerPosition.y, minY + paddingY, maxY - paddingY);

        return position;
    }

}
