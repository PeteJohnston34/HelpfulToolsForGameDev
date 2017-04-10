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
                        _rightChild.push(key, element, level - 1, offset - 1);
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
                        _rightChild.push(key, element, level - 1, offset - (int)Math.Pow(2, level - 1));
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

            switch (level)
            {
                case 0:
                    return this;
                case 1:
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
                default:
                    return right ? _rightChild.pop(level - 1, offset - (int)Math.Pow(2, level - 1)) : _leftChild.pop(level - 1, offset);
            }           
        }

        public void heapUp()
        {
            if (_parent == null) { return; }

            IComparable thisCompKey = (IComparable)Key;
            IComparable parentCompKey = (IComparable)_parent.Key;

            if (HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MaxHeap &&
                    parentCompKey.CompareTo(thisCompKey) < 0 ||
                    HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MinHeap &&
                    parentCompKey.CompareTo(thisCompKey) > 0)
            {
                swap(this, _parent);
                _parent.heapUp();                
            }
        }

        public void heapDown(int level)
        {
            IComparable thisKey = (IComparable)Key;

            if (level == 0)
            {
                return;
            }
            if (level == 1)
            {
                if (_leftChild == null && _rightChild == null)
                {
                    return;
                }
                if (_rightChild == null)
                {
                    heapDownLeft(thisKey, level);
                    return;                    
                }
            }
            
            IComparable leftKey = (IComparable)_leftChild.Key;
            IComparable rightKey = (IComparable)_rightChild.Key;

            if (HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MaxHeap && leftKey.CompareTo(rightKey) > 0 ||
                HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MinHeap && leftKey.CompareTo(rightKey) < 0)
            {
                heapDownLeft(thisKey, level);
            }
            else
            {
                heapDownRight(thisKey, level);
            }
        }

        //private methods
        private void heapDownLeft(IComparable thisKey, int level)
        {
            IComparable leftKey = (IComparable)_leftChild.Key;

            if (HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MaxHeap && thisKey.CompareTo(leftKey) < 0 ||
                HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MinHeap && thisKey.CompareTo(leftKey) > 0)
            {
                swap(this, _leftChild);

                _leftChild.heapDown(level - 1);
            }

        }

        private void heapDownRight(IComparable thisKey, int level)
        {
            IComparable rightKey = (IComparable)_rightChild.Key;

            if (HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MaxHeap && thisKey.CompareTo(rightKey) < 0 ||
                HeapTreeImplementation<K, T>.PriorityType == HeapPriorityType.MinHeap && thisKey.CompareTo(rightKey) > 0)
            {
                swap(this, _rightChild);
                
                _rightChild.heapDown(level - 1);
            }
        }

        private void swap(HeapNode<K, T> node1, HeapNode<K, T> node2)
        {
            T tempElement = node1.Element;
            K tempKey = node1.Key;

            node1.Element = node2.Element;
            node1.Key = node2.Key;

            node2.Element = tempElement;
            node2.Key = tempKey;
        }
    }
}
