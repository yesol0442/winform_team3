using client.BlockForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace client.HambugiGame
{

    // 현재 포커스된 BlockBase를 전역으로 기억하고, 바뀔 때마다 이전/새 컨트롤을 Invalidate() 하여 하이라이트 다시 그리게 해 주는 단순 헬퍼.
    public static class FocusManager
    {
        private static BlockBase _current;

        public static BlockBase Current => _current;

        // 포커스 대상 변경. 같은 블록이면 무시.
        public static void Set(BlockBase block)
        {
            if (_current == block) return;

            _current?.Invalidate();  // 기존 블록 다시 그려서 하이라이트 제거
            _current = block;
            _current?.Invalidate();   // 새 블록 하이라이트
        }

        // 포커스 해제(모든 블록 비선택).
        public static void Clear()
        {
            _current?.Invalidate();
            _current = null;
        }
    }
}