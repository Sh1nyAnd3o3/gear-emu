/* --------------------------------------------------------------------------------
 * Gear: Parallax Inc. Propeller Debugger
 * Copyright 2007 - Robert Vandiver
 * --------------------------------------------------------------------------------
 * HubView.cs
 * Propeller \ Hub settings viewer class
 * --------------------------------------------------------------------------------
 *  This program is free software; you can redistribute it and/or modify
 *  it under the terms of the GNU General Public License as published by
 *  the Free Software Foundation; either version 2 of the License, or
 *  (at your option) any later version.
 *
 *  This program is distributed in the hope that it will be useful,
 *  but WITHOUT ANY WARRANTY; without even the implied warranty of
 *  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *  GNU General Public License for more details.
 *
 *  You should have received a copy of the GNU General Public License
 *  along with this program; if not, write to the Free Software
 *  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA  02111-1307  USA
 * --------------------------------------------------------------------------------
 */

using Gear.EmulationCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Gear.GUI
{
    /// @brief GUI Control to show Hub status
    public partial class HubView : UserControl
    {
        /// @brief Reference to propeller cpu instance.
        private PropellerCPU m_Host;

        /// @brief Property to set the %Propeller %Host.
        public PropellerCPU Host
        {
            set
            {
                m_Host = value;
                DataChanged();
            }
        }

        /// @brief Default constructor
        public HubView()
        {
            InitializeComponent();
        }

        /// @brief Update screen data on event.
        /// 
        public void DataChanged()
        {
            if (m_Host == null)
                return;

            pinDIR.Value = m_Host.DIR;
            pinIN.Value = m_Host.IN;
            pinFloating.Value = m_Host.Floating;
            pinLocksFree.Value = m_Host.LocksFree;
            pinLocks.Value = m_Host.Locks;

            systemCounter.Text = m_Host.Counter.ToString();
            coreFrequency.Text = m_Host.CoreFrequency.ToString() + "hz";
            xtalFrequency.Text = m_Host.XtalFrequency.ToString() + "hz";
            clockMode.Text = m_Host.Clock;

            ringMeter.Value = m_Host.Ring;
        }

    }
}
