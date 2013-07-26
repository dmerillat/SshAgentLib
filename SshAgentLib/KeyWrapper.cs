﻿//
// KeyWrapper.cs
//
// Author(s): David Lechner <david@lechnology.com>
//
// Copyright (c) 2012-2013 David Lechner
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

namespace dlech.SshAgentLib
{
  public class KeyWrapper
  {
    private ISshKey mKey;

    public bool Confirm
    {
      get
      {
        return mKey.HasConstraint(Agent.KeyConstraintType.SSH_AGENT_CONSTRAIN_CONFIRM);
      }
    }

    public bool Lifetime
    {
      get
      {
        return mKey.HasConstraint(Agent.KeyConstraintType.SSH_AGENT_CONSTRAIN_LIFETIME);
      }
    }

    public string Type
    {
      get
      {
        return mKey.Algorithm.GetIdentifierString();
      }
    }

    public int Size
    {
      get
      {
        return mKey.Size;
      }
    }

    public string Fingerprint
    {
      get
      {
        return mKey.GetMD5Fingerprint().ToHexString();
      }
    }

    public string Comment
    {
      get
      {
        return mKey.Comment;
      }
    }
    
    public KeyWrapper(ISshKey aKey)
    {
      mKey = aKey;
    }

    public ISshKey GetKey()
    {
      return mKey;
    }

  }
}
