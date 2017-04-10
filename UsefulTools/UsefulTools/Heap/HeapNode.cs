using System;

namespace UsefulTools.Heap
{
    class HeapNode<K, T>
    {
        //members
        private HeapNode<K, T> _leftChild;
        private HeapNode<K, T> _rightChild;
        private HeapNode<K, T> _parent;
        private T _element;
        private K _key;

        //properties
        public T Element
        {
            get { return _element; }
            set { _element = value; }
        }
        public K Key
        {
            get { return _key; }
            set { _key = value; }
        }

        //constructor
        public HeapNode(HeapNode<K, T> parent)
        {
            _parent = parent;
        }

        //public methods
        public void push(K key, T element, int level, int offset)
        {
            bool right = offset > Math.Pow(2, level) / 2;
            switch (level)
            {
                case 0:
                    _element = element;
                    _key = key;
                    heapUp();
                    break;
                case 1:
                    if (right)
                    {
                        _rightChild = new HeapNode<K, T>(this);
                        _rightChild.push(key, element, level - 1, offset);
                    }
                    else
                    {
                        _leftChild = new HeapNode<K, T>(this);
                        _leftChild.push(key, element, level - 1, offset);
                    }
                    break;
                default:
                    if (right)
                    {
                        _rightChild.push(key, element, level - 1, offset);
                    }
                    else
                    {
                        _leftChild.push(key, element, level - 1, offset);
                    }
                    break;
            }
        }

        public HeapNode<K, T> pop(int level, int offset)
        {
            bool right = offset > Math.Pow(2, level) / 2;

            if (level == 0)
            {
                return this;
            }

            if (level == 1)
            {
                if (right)
                {
                    HeapNode<K, T> tempNode = _rightChild;
                    _rightChild = null;
                    return tempNode;
                }
                else
                {
                    HeapNode<K, T> tempNode = _leftChild;
                    _leftChild = null;
                    return tempNode;
                }
            }
            else
            {
                return right ? _rightChild.pop(level - 1, offset) : _leftChild.pop(level - 1, offset);
            }
        }

        public void heapUp()
        {
            if (_parent == null) { return; }

            IComparable thisCompKey = (IComparable)_key;
            IComparable parentCompKey = (IComparable)_parent.Key;

            if (HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MaxHeap)
            {
                if (parentCompKey.CompareTo(thisCompKey) < 0)
                {
                    T tempElement = _parent.Element;
                    K tempKey = _parent.Key;

                    _parent.Element = Element;
                    _parent.Key = Key;

                    Element = tempElement;
                    Key = tempKey;

                    _parent.heapUp();
                }
            }
            else
            {
                if (parentCompKey.CompareTo(thisCompKey) > 0)
                {
                    T tempElement = _parent.Element;
                    K tempKey = _parent.Key;

                    _parent.Element = Element;
                    _parent.Key = Key;

                    Element = tempElement;
                    Key = tempKey;

                    _parent.heapUp();
                }
            }
        }

        public void heapDown(int level)
        {
            IComparable thisKey = (IComparable)Key;
            if (level == 1)
            {
                if (_leftChild == null && _rightChild == null) { return; }
                if (_leftChild == null)
                {
                    heapDownRight(thisKey);
                    return;
                }
                if (_rightChild == null)
                {
                    heapDownLeft(thisKey);
                    return;
                }
            }

            IComparable leftKey = (IComparable)_leftChild.Key;
            IComparable rightKey = (IComparable)_rightChild.Key;

            if (HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MaxHeap && leftKey.CompareTo(rightKey) > 0 ||
                HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MinHeap && leftKey.CompareTo(rightKey) < 0)
            {
                heapDownLeft(thisKey);
            }
            else
            {
                heapDownRight(thisKey);
            }
        }

        private void heapDownLeft(IComparable thisKey)
        {
            IComparable leftKey = (IComparable)_leftChild.Key;

            if (HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MaxHeap && thisKey.CompareTo(leftKey) < 0 ||
                HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MinHeap && thisKey.CompareTo(leftKey) > 0)
            {
                T tempElement = _leftChild.Element;
                K tempKey = _leftChild.Key;

                _leftChild.Element = Element;
                _leftChild.Key = Key;

                Element = tempElement;
                Key = tempKey;
            }

        }

        private void heapDownRight(IComparable thisKey)
        {
            IComparable rightKey = (IComparable)_rightChild.Key;

            if (HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MaxHeap && thisKey.CompareTo(rightKey) < 0 ||
    HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MinHeap && thisKey.CompareTo(rightKey) > 0)
            {
                T tempElement = _rightChild.Element;
                K tempKey = _rightChild.Key;

                _rightChild.Element = Element;
                _rightChild.Key = Key;

                Element = tempElement;
                Key = tempKey;
            }
        }
    }
}
