using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public interface IPlayerState
    {
        public enum State
        {
            Idle,
            Walk,
            Run,
            Jump,
        
            Max, // 状態の数(StateのEnumの数)をカウントするためのダミー
        
            UnChanged, // 状態が変化していないことを示すためのダミー
        }
        
        State Initialize(PlayerBehaviour parent);
        State Update(PlayerBehaviour parent);
    }

    // MAXを使用することで、ステートの実装のし忘れをエラーで知らせる。
    private static readonly IPlayerState[] _playerStates = new IPlayerState[(int)IPlayerState.State.Max]
    {
        new IdleState(),
        new WalkState(),
        new RunState(),
        new JumpState(),
    };
    
    private IPlayerState.State _currentState = IPlayerState.State.Idle;

    // 可変変数はParent(PlayerBehaviour)クラス内に実装する。
    // Stateの処理実装クラスには可変変数は基本的に実装を行ってはならない！（共通のクラスを使うため）
    private float health = 100.0f;
    private float mana = 100.0f;

    void Start()
    {
        // ステートマシンの初期化
        InitializeState();
    }
    
    void Update()
    {
        // ステートマシンの更新
        UpdateState();
    }

    // ステートマシン を動かすのに必要な関数
    #region StateMachine Method

    public IPlayerState.State GetCurrentState()
    {
        return _currentState;
    }
    
    public void SetState(IPlayerState.State state)
    {
        if (state == IPlayerState.State.UnChanged)
        {
            return;
        }

        _currentState = state;
        InitializeState();
    }
    
    public void InitializeState()
    {
        var nextState = _playerStates[(int)_currentState].Initialize(this);
        
        if (nextState != IPlayerState.State.UnChanged)
        {
            SetState(nextState);
        }
    }
    
    public void UpdateState()
    {
        var nextState = _playerStates[(int)_currentState].Update(this);
        
        if (nextState != IPlayerState.State.UnChanged)
        {
            SetState(nextState);
        }
    }

    #endregion



    // ステートマシーンの実処理の実行クラス
    #region StateMechine Implementation

    private class IdleState : IPlayerState
    {
        public IPlayerState.State Initialize(PlayerBehaviour parent)
        {
            // 初期化処理
            return IPlayerState.State.UnChanged;
        }

        public IPlayerState.State Update(PlayerBehaviour parent)
        {
            // 更新処理
            return IPlayerState.State.UnChanged;
        }
    }
    
    private class WalkState : IPlayerState
    {
        public IPlayerState.State Initialize(PlayerBehaviour parent)
        {
            // 初期化処理
            return IPlayerState.State.UnChanged;
        }

        public IPlayerState.State Update(PlayerBehaviour parent)
        {
            // 更新処理
            return IPlayerState.State.UnChanged;
        }
    }
    
    private class RunState : IPlayerState
    {
        public IPlayerState.State Initialize(PlayerBehaviour parent)
        {
            // 初期化処理
            return IPlayerState.State.UnChanged;
        }

        public IPlayerState.State Update(PlayerBehaviour parent)
        {
            // 更新処理
            return IPlayerState.State.UnChanged;
        }
    }
    
    private class JumpState : IPlayerState
    {
        public IPlayerState.State Initialize(PlayerBehaviour parent)
        {
            // 初期化処理
            return IPlayerState.State.UnChanged;
        }

        public IPlayerState.State Update(PlayerBehaviour parent)
        {
            // 更新処理
            return IPlayerState.State.UnChanged;
        }
    }

    #endregion
