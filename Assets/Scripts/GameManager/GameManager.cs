using UnityEngine;
using System.Collections;

using Global;

public class GameManager : MonoBehaviour 
{
    private HeroesController heroesCtr;
    private CameraController cameraCtr;
    private UIController uiCtr;
    private EnemyController enemyCtr;
    private WeaponFactory weaponFact;

    public HeroesController getHeroesCtr()
    {
        if (!heroesCtr)
            heroesCtr = GetComponent<HeroesController>();

        return heroesCtr;
    }

    public EnemyController getEnemyCtr()
    {
        if (!enemyCtr)
            enemyCtr = GetComponent<EnemyController>();

        return enemyCtr;
    }

    public CameraController getCameraCtr()
    {
        if (!cameraCtr)
            cameraCtr = GetComponent<CameraController>();

        return cameraCtr;
    }

    public UIController getUICtr()
    {
        if (!uiCtr)
            uiCtr = GetComponent<UIController>();

        return uiCtr;
    }

    public WeaponFactory getWeaponFact()
    {
        if (!weaponFact)
            weaponFact = GetComponent<WeaponFactory>();

        return weaponFact;
    }
}
