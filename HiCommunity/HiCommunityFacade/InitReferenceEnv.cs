﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HiCommunityDBAccessor;

namespace HiCommunityFacade
{
    public class InitReferenceEnv
    {
        private static bool EnvInitialized = false;

        public static void InitSubAssembliesEnv(string hiCommunityConn)
        {
            if (!EnvInitialized)
            {
                DBConnectionMgr.HiCommunityConnectionString = hiCommunityConn;
                EnvInitialized = true;
            }
        }
    }
}
