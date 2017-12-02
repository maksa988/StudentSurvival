using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Camera))]

public class CameraController : MonoBehaviour
{

    private enum Mode { Player, Cursor };

    [SerializeField]
    private Mode face; // вектор смещения, относительно "лица" персонажа или положения курсора
    [SerializeField]
    private float smooth = 2.5f; // сглаживание при следовании за персонажем
    [SerializeField]
    private float offset; // значение смещения (отключить = 0)
    [SerializeField]
    private SpriteRenderer boundsMap; // спрайт, в рамках которого будет перемещаться камера
    [SerializeField]
    private bool useBounds = true; // использовать или нет, границы для камеры

    private Transform player;
    private Vector3 min, max, direction;
    private static CameraController _use;
    private Camera cam;

    public static CameraController use
    {
        get { return _use; }
    }

    void Awake()
    {
        _use = this;
        cam = GetComponent<Camera>();
        cam.orthographic = true;
        FindPlayer();
        CalculateBounds();
    }

    // переключатель, для использования из другого класса
    public void UseCameraBounds(bool value)
    {
        useBounds = value;
    }

    // найти персонажа, если он был уничтожен, а потом возрожден
    // для вызова из другого класса, пишем: CameraController.use.FindPlayer();
    public void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if (player) transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }

    // если в процессе игры, было изменено разрешение экрана
    // или параметр "Orthographic Size", то следует сделать вызов данной функции повторно
    public void CalculateBounds()
    {
        if (boundsMap == null) return;
        Bounds bounds = Camera2DBounds();
        min = bounds.max + boundsMap.bounds.min;
        max = bounds.min + boundsMap.bounds.max;
    }

    Bounds Camera2DBounds()
    {
        float height = cam.orthographicSize * 2;
        return new Bounds(Vector3.zero, new Vector3(height * cam.aspect, height, 0));
    }

    Vector3 MoveInside(Vector3 current, Vector3 pMin, Vector3 pMax)
    {
        current = Vector3.Max(current, pMin);
        current = Vector3.Min(current, pMax);
        return current;
    }

    Vector3 Mouse()
    {
        Vector3 mouse = Input.mousePosition;
        mouse.z = -transform.position.z;
        return cam.ScreenToWorldPoint(mouse);
    }

    void Follow()
    {
        if (face == Mode.Player) direction = player.right; else direction = (Mouse() - player.position).normalized;
        Vector3 position = player.position + direction * offset;
        position.z = -10.0F;
        position.y += 2.8F;
        position = MoveInside(position, new Vector3(min.x, min.y, position.z), new Vector3(max.x, max.y, position.z));
        transform.position = Vector3.Lerp(transform.position, position, smooth * Time.deltaTime);
    }

    void LateUpdate()
    {
        if (player)
        {
            Follow();
        }
    }
}