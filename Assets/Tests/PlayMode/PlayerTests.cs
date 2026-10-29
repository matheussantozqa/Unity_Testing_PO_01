using System.Collections;
using Game;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

/// <summary>
/// PlayMode: testes que precisam de frames, Update e física.
/// </summary>
public class PlayerTests
{
    private Player _player;
    private GameObject _coin;

    [SetUp]
    public void SetUp()
    {
        var go = GameObject.CreatePrimitive(PrimitiveType.Cube); // já vem com BoxCollider
        go.AddComponent<Rigidbody>().isKinematic = true;          // necessário para disparar o trigger
        _player = go.AddComponent<Player>();
        _player.useKeyboard = false;
    }

    [TearDown] // limpa a cena para um teste não afetar o outro
    public void TearDown()
    {
        if (_player != null) Object.Destroy(_player.gameObject);
        if (_coin != null) Object.Destroy(_coin);
    }

    [UnityTest]
    public IEnumerator Player_SemInput_FicaParado()
    {
        Vector3 inicio = _player.transform.position;

        yield return null; // espera 1 frame

        Assert.AreEqual(inicio, _player.transform.position);
    }

    [UnityTest]
    public IEnumerator Player_ComInputParaDireita_AndaParaDireita()
    {
        Vector3 inicio = _player.transform.position;
        _player.moveInput = Vector2.right;

        yield return new WaitForSeconds(0.2f);

        Assert.Greater(_player.transform.position.x, inicio.x);
        Assert.AreEqual(inicio.z, _player.transform.position.z, 0.001f);
    }

    [UnityTest]
    public IEnumerator Player_EncostaNaMoeda_GanhaPontosEMoedaSome()
    {
        _coin = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        _coin.GetComponent<Collider>().isTrigger = true;
        _coin.AddComponent<Coin>().points = 10;
        _coin.transform.position = _player.transform.position; // em cima do player

        yield return new WaitForFixedUpdate(); // física processa o trigger
        yield return null;                     // Destroy acontece no fim do frame

        Assert.AreEqual(10, _player.Score.Score);
        Assert.IsTrue(_coin == null, "A moeda deveria ter sido destruída");
    }
}
