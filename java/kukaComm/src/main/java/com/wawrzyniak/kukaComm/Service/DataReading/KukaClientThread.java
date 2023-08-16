package com.wawrzyniak.kukaComm.Service.DataReading;

import com.wawrzyniak.kukaComm.Model.KRLVar;


import java.util.HashSet;
import java.util.Set;

public class KukaClientThread extends Thread {
    private final KukaClient client;
    private final Set<KRLVar> variables;

    KukaClientThread(KukaClient client) {
        this.client = client;
        this.variables = new HashSet<>();
    }

<<<<<<< refs/remotes/origin/main
<<<<<<< refs/remotes/origin/main
    public void addVariable(KRLVar var) {
=======
    public void addVariable(KRLVar var){
>>>>>>> add testSocket and kukaComm
=======
    public void addVariable(KRLVar var) {
>>>>>>> add swagger docs, fix some whitespace issues
        synchronized (this.variables) {
            variables.add(var);
        }
    }

    @Override
    public void run() {
        while(!Thread.currentThread().isInterrupted()) {
            variables.forEach(KRLVar::clearExceptions);
            synchronized (this.variables) {
                for (KRLVar var : variables) {
                    client.readVar(var);
                }
            }
            try {
                Thread.sleep(10);
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
            }
        }
    }
}
