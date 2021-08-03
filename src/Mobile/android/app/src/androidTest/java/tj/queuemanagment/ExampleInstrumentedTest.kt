/*
 *
 *  * Created by Bahromzoda Behruz on 03.08.2021, 20:45
 *  * Copyright (c) 2021 . All rights reserved.
 *  * Last modified 03.08.2021, 13:42
 *  */


package tj.queuemanagment

import androidx.test.platform.app.InstrumentationRegistry
import androidx.test.ext.junit.runners.AndroidJUnit4

import org.junit.Test
import org.junit.runner.RunWith

import org.junit.Assert.*

/**
 * Instrumented test, which will execute on an Android device.
 *
 * See [testing documentation](http://d.android.com/tools/testing).
 */
@RunWith(AndroidJUnit4::class)
class ExampleInstrumentedTest {
    @Test
    fun useAppContext() { // Context of the app under test.
        val appContext = InstrumentationRegistry.getInstrumentation().targetContext
        assertEquals("tj.queuemanagment", appContext.packageName)
    }
}